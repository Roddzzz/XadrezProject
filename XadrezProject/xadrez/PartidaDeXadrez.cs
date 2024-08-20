﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XadrezProject.tabuleiro;

namespace XadrezProject.xadrez {
    internal class PartidaDeXadrez {
        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; }
        private HashSet<Peca> pecas;

        public PartidaDeXadrez() {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            terminada = false;
        }

        public void executaMovimento(Posicao origem, Posicao destino) {
            Peca p = tab.retirarPeca(origem);
            p.incrementarQteMovimentos();
            Peca pecaCapturada = tab.retirarPeca(destino);
            tab.colocarPeca(p, destino); 
        }

        public void realizaJogada(Posicao origem, Posicao destino) {
            executaMovimento(origem, destino);
            turno++;
            mudaJogador();
        }

        public void validarPosicaoDeOrigem(Posicao pos) {
            if (tab.peca(pos) == null) {
                throw new TabuleiroException("Não existe peca na posição de origem escolhida!");
            }
            if(jogadorAtual != tab.peca(pos).cor) {
                throw new TabuleiroException("A peça escolhida não é sua!");
            }
            if (!tab.peca(pos).existeMovimentosPossiveis()) {
                throw new TabuleiroException("Não há moviemntos possiveis para a peça de origem escolhida!");
            }
        }

        public void validarPosicaoDeDestino(Posicao origem, Posicao destino) {
            if (!tab.peca(origem).podeMoverPara(destino)) {
                throw new TabuleiroException("Posição de destino invalida");
            }
        }

        private void mudaJogador() {
            if(jogadorAtual == Cor.Branca) {
                jogadorAtual = Cor.Preta;
            }
            else {
                jogadorAtual = Cor.Branca;
            }
        }

        public void colocarNovaPeca(char coluna, int linha, Peca peca) {
            tab.colocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
            pecas.Add(peca);
        }

        private void colocarPecas() {
            colocarNovaPeca('a', 1, new Torre(tab, Cor.Branca));
            //colocarNovaPeca('b', 1, new Cavalo(tab, Cor.Branca));
            //colocarNovaPeca('c', 1, new Bispo(tab, Cor.Branca));
            //colocarNovaPeca('d', 1, new Dama(tab, Cor.Branca));
            //colocarNovaPeca('e', 1, new Rei(tab, Cor.Branca, this));
            //colocarNovaPeca('f', 1, new Bispo(tab, Cor.Branca));
            //colocarNovaPeca('g', 1, new Cavalo(tab, Cor.Branca));
            //colocarNovaPeca('h', 1, new Torre(tab, Cor.Branca));
            //colocarNovaPeca('a', 2, new Peao(tab, Cor.Branca, this));
            //colocarNovaPeca('b', 2, new Peao(tab, Cor.Branca, this));
            //colocarNovaPeca('c', 2, new Peao(tab, Cor.Branca, this));
            //colocarNovaPeca('d', 2, new Peao(tab, Cor.Branca, this));
            //colocarNovaPeca('e', 2, new Peao(tab, Cor.Branca, this));
            //colocarNovaPeca('f', 2, new Peao(tab, Cor.Branca, this));
            //colocarNovaPeca('g', 2, new Peao(tab, Cor.Branca, this));
            //colocarNovaPeca('h', 2, new Peao(tab, Cor.Branca, this));

            //colocarNovaPeca('a', 8, new Torre(tab, Cor.Preta));
            //colocarNovaPeca('b', 8, new Cavalo(tab, Cor.Preta));
            //colocarNovaPeca('c', 8, new Bispo(tab, Cor.Preta));
            //colocarNovaPeca('d', 8, new Dama(tab, Cor.Preta));
            //colocarNovaPeca('e', 8, new Rei(tab, Cor.Preta, this));
            //colocarNovaPeca('f', 8, new Bispo(tab, Cor.Preta));
            //colocarNovaPeca('g', 8, new Cavalo(tab, Cor.Preta));
            //colocarNovaPeca('h', 8, new Torre(tab, Cor.Preta));
            //colocarNovaPeca('a', 7, new Peao(tab, Cor.Preta, this));
            //colocarNovaPeca('b', 7, new Peao(tab, Cor.Preta, this));
            //colocarNovaPeca('c', 7, new Peao(tab, Cor.Preta, this));
            //colocarNovaPeca('d', 7, new Peao(tab, Cor.Preta, this));
            //colocarNovaPeca('e', 7, new Peao(tab, Cor.Preta, this));
            //colocarNovaPeca('f', 7, new Peao(tab, Cor.Preta, this));
            //colocarNovaPeca('g', 7, new Peao(tab, Cor.Preta, this));
            //colocarNovaPeca('h', 7, new Peao(tab, Cor.Preta, this));
        }
    }
}
