using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MaterialDesignColors;
using MaterialDesignThemes.Wpf;
using MUnique.OpenMU.Launcher.Managers;
using Prism.Commands;
using Prism.Mvvm;

namespace MUnique.OpenMU.Launcher.ViewModels
{
    public class ColorOptionsViewModel : BindableBase
    {
        public ColorOptionsViewModel()
        {
            setPrimaryCommand = new DelegateCommand<string>(s =>
            {
                PaletteHelper.ReplacePrimaryColor(s);
                SettingsManager.Settings.PrimaryColor = s;
            });

            setAccentCommand = new DelegateCommand<string>(s =>
            {
                PaletteHelper.ReplaceAccentColor(s);
                SettingsManager.Settings.AccentColor = s;
            });

            setDarkMode = new DelegateCommand(() =>
            {
                PaletteHelper.SetLightDark(DarkMode);
            });

            this.RaisePropertyChanged();
        }

        public static readonly PaletteHelper PaletteHelper = new PaletteHelper();
        public static readonly SwatchesProvider SwatchesProvider = new SwatchesProvider();

        public bool DarkMode
        {
            get => SettingsManager.Settings.DarkMode;
            set => SettingsManager.Settings.DarkMode = value;
        }


        private IEnumerable<Swatch> swatches = SwatchesProvider.Swatches;

        public IEnumerable<Swatch> Swatches
        {
            get => swatches;
            set => SetProperty(ref swatches, value);
        }

        private ICommand setPrimaryCommand;

        public ICommand SetPrimaryCommand
        {
            get => setPrimaryCommand;
            set => SetProperty(ref setPrimaryCommand, value);
        }

        private ICommand setAccentCommand;

        public ICommand SetAccentCommand
        {
            get => setAccentCommand;
            set => SetProperty(ref setAccentCommand, value);
        }

        private ICommand setDarkMode;

        public ICommand SetDarkMode
        {
            get => setDarkMode;
            set => SetProperty(ref setDarkMode, value);
        }


    }
}
