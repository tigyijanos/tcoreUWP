using System;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace TCore.UniversalApp.Helpers.Common
{
    public static class DialogHelpers
    {
        public static async Task ShowSimpleDialog(string message, string title = "")
        {
            var messageDialog = new MessageDialog(message, title);

            await messageDialog.ShowAsync();
        }

        public async static Task<bool> ShowAreYouSureDialog(string message,string yesLocalization = "Yes", string noLocalization = "No")
        {
            bool sure = false;
            var title = message;
            var content = message;

            var yesCommand = new UICommand(yesLocalization, cmd => { });
            var noCommand = new UICommand(noLocalization, cmd => { });

            var dialog = new MessageDialog(content, title);
            dialog.Options = MessageDialogOptions.None;
            dialog.Commands.Add(yesCommand);

            dialog.DefaultCommandIndex = 0;
            dialog.CancelCommandIndex = 0;

            if (noCommand != null)
            {
                dialog.Commands.Add(noCommand);
                dialog.CancelCommandIndex = (uint)dialog.Commands.Count - 1;
            }

            var command = await dialog.ShowAsync();

            if (command == yesCommand)
            {
                sure = true;
            }

            return sure;
        }
    }
}
