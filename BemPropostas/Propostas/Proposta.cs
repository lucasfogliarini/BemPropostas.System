﻿namespace BemPropostas
{
    public class Proposta
    {
        public int Id { get; set; }
        public string Numero { get; private set; }
        public decimal ValorSolicitado { get; private set; }
        public int Prazo { get; private set; }
        public decimal TaxaJuros { get; private set; }
        public decimal ValorParcela { get; private set; }
        public StatusProposta Status { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime? DataAprovacao { get; private set; }
        //public Cliente Cliente { get; private set; }
        public int ClienteId { get; private set; }

        private Proposta() { }

        public Proposta(int clienteId, decimal valorSolicitado, int prazo)
        {
            Numero = GenerateNumeroProposta();
            ClienteId = clienteId;
            ValorSolicitado = valorSolicitado;
            Prazo = prazo;
            Status = StatusProposta.Solicitada;
            DataCriacao = DateTime.UtcNow;
        }

        public void AprovarFinanceiramente(decimal taxaJuros, decimal valorParcela)
        {
            if (Status != StatusProposta.Solicitada)
                throw new InvalidOperationException("A proposta não pode ser aprovada neste estado.");

            TaxaJuros = taxaJuros;
            ValorParcela = valorParcela;
            Status = StatusProposta.AprovadaFinanceiramente;
            DataAprovacao = DateTime.UtcNow;
        }

        public void Rejeitar()
        {
            if (Status != StatusProposta.Solicitada)
                throw new InvalidOperationException("A proposta não pode ser rejeitada neste estado.");

            Status = StatusProposta.Rejeitada;
        }

        private string GenerateNumeroProposta()
        {
            return $"PROP-{DateTime.UtcNow:yyyyMMddHHmmss}-{new Random().Next(1000, 9999)}";
        }
    }

    public enum StatusProposta
    {
        Solicitada,
        //EmAnaliseFinanceira,
        AprovadaFinanceiramente,        
        AprovadaPeloCliente,
        ContratoAssinado,
        Rejeitada,
        Cancelada
    }
}
