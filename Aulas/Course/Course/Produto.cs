using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course {
    internal class Produto {

        private string _nome;

        //auto property
        public double Preco { get; private set; }
        public int Quantidade { get; private set; }

        //tipos de construtores
        public Produto() {
            Quantidade = 0;
        }

        //this (pra puxar construtores padroes)
        public Produto(string nome, double preco) : this() {
            _nome = nome;
            Preco = preco;
        }

        public Produto(string nome, double preco, int quantidade) : this(nome, preco) {
        }

        //getters e setters property
        public string Nome {
            get { return _nome; }
            set {
                if(value != null && value.Length > 1)
                    _nome = value;
            }
        }

        public override string ToString() {
            return $"{_nome}, ${Preco:F2}, {Quantidade} unidades, Total: ${TotalValueInStock():F2}";
        }

        public double TotalValueInStock() {
            return Preco * Quantidade;
        }

        public void addProductsToStock(int amount) {
            Quantidade += amount;
        }

        public void removeProductsFromStock(int amount) {
            Quantidade -= amount;
        }
    }
}
