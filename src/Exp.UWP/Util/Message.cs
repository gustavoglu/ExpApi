using System;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace Exp.UWP
{
    public class Message
    {
        public static async void Erro(string msg)
        {
            MessageDialog md = new MessageDialog(msg, "Erro");
            await md.ShowAsync();
        }

        public static async void Aviso(string msg)
        {
            MessageDialog md = new MessageDialog(msg, "Atenção");
            await md.ShowAsync();
        }

        public static async Task<bool> Escolha(string msg)
        {
            MessageDialog md = new MessageDialog(msg, "Atenção");
            md.Commands.Add(new UICommand("Sim"));
            md.Commands.Add(new UICommand("Não"));
            var escolha = await md.ShowAsync();
            if (escolha.Label == "Sim") return true;
            return false;
        }
    }
}
