using System;
using System.Globalization;
using System.Security.Principal;
using XadrezProject;
using XadrezProject.tabuleiro;
using XadrezProject.xadrez;

public class Program {
    public static void Main() {
        try {
            Tabuleiro tab = new Tabuleiro(8, 8);

            tab.colocarPeca(new Torre(tab, Cor.Preta), new Posicao(0, 3));
            tab.colocarPeca(new Torre(tab, Cor.Branca), new Posicao(0, 7));

            Tela.imprimirTabuleiro(tab);
        }
        catch (TabuleiroException e) {
            Console.WriteLine(e.Message);
        }

    }
}
