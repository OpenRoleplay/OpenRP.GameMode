using OpenRP.GameMode.Definitions.Constants;
using OpenRP.GameMode.Features.Accounts.Components;
using OpenRP.GameMode.Features.Chat.Constants;
using SampSharp.Entities.SAMP;
using System;

namespace OpenRP.GameMode.Features.MainMenu.Dialogs
{
    public static class RegisterStepTwoDialog
    {
        public static void Open(Player player, IDialogService dialogService)
        {
            InputDialog registerDialog = new InputDialog();

            registerDialog.Caption = DialogConstants.Prefix + "Registration" + DialogConstants.Separator + "Password";
            registerDialog.Content = ChatColor.White + "What would you like your password to be?";
            registerDialog.Button1 = DialogConstants.Next;
            registerDialog.Button2 = DialogConstants.Previous;
            registerDialog.IsPassword = true;

            void StepTwoDialogHandler(InputDialogResponse r)
            {
                if (r.Response == DialogResponse.LeftButton)
                {
                    if (r.InputText.Length < 8)
                    {
                        MessageDialog passwordMustBeLongerThanEightCharactersDialog = new MessageDialog(DialogConstants.Prefix + "Registration" + DialogConstants.Separator + "Password", ChatColor.White + "Your password must be longer than 8 characters.", DialogConstants.Retry);

                        void PasswordMustBeLongerThanEightCharactersDialogHandler(MessageDialogResponse r)
                        {
                            Open(player, dialogService);
                        };

                        dialogService.Show(player.Entity, passwordMustBeLongerThanEightCharactersDialog, PasswordMustBeLongerThanEightCharactersDialogHandler);
                    }

                    AccountComponent accountComponent = player.GetComponent<AccountComponent>();

                    if (String.IsNullOrEmpty(accountComponent?.Account?.Password))
                    {
                        accountComponent.Account.Password = BCrypt.Net.BCrypt.HashPassword(r.InputText, 11);

                        MessageDialog passwordSet = new MessageDialog(DialogConstants.Prefix + "Registration" + DialogConstants.Separator + "Password", ChatColor.White + "Your password has been set. You must now confirm your password.", DialogConstants.Next);

                        void PasswordSetHandler(MessageDialogResponse r)
                        {
                            RegisterStepThreeDialog.Open(player, dialogService);
                        };

                        dialogService.Show(player.Entity, passwordSet, PasswordSetHandler);
                    }
                }
                else
                {
                    RegisterStepOneDialog.Open(player, dialogService);
                }
            }

            dialogService.Show(player.Entity, registerDialog, StepTwoDialogHandler);
        }
    }
}
