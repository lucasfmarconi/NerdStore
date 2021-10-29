using System;
using Nerstore.Core.DomainObjects;

namespace NerdStore.Catalogo.Domain
{
    public class Produto : Entity, IAggregateRoot
    {


        public string Nome { get; private set; }

        public string Descricao { get; private set; }

        public bool Ativo { get; private set; }

        public int QuantidadeEstoque { get; private set; }

        public Guid CategoriaId { get; private set; }

        public Categoria Categoria { get; private set; }

        public Produto()
        {

        }

        public void Ativar() => Ativo = true;
        public void Desativar() => Ativo = false;

        public void AlterarCategoria(Categoria categoria)
        {
            Categoria.Id = categoria.Id;
            Categoria = categoria;
        }

        public void AlterarDescricao(Categoria descricao)
        {
            Descricao = Descricao;
        }

        public void DebitarEstoque(int quantidade)
        {
            if (quantidade < 0) quantidade *= -1;
            QuantidadeEstoque -= quantidade;
        }

        public void ReporEstoque(int quantidade)
        {
            QuantidadeEstoque += quantidade;
        }

        public bool PossuiEstoque(int quantidade)
        {
            return QuantidadeEstoque >= quantidade;
        }

        public void Validar()
        {

        }

    }

    public class Categoria : Entity
    {
        public string Nome { get; private set; }

        public int Codigo { get; private set; }

        public Categoria()
        {

        }

        public override string ToString()
        {
            return $"{Nome} - {Codigo}";
        }
    }



}
