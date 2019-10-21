using CrudWpfCore.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace CrudWpfCore.ViewModel
{
    public class SongViewModel : BaseNotifyPropertyChanged
    {
        public ObservableCollection<Song> Songs { get; private set; }
        public NewCommand New { get; private set; } = new NewCommand();
        public EditCommand Edit { get; private set; } = new EditCommand();
        public DeleteCommand Delete { get; private set; } = new DeleteCommand();
        private Song _selectedSong;
        public Song SelectedSong
        {
            get => _selectedSong;
            set 
            { 
                SetField(ref _selectedSong, value);
                Delete.RaiseCanExecuteChanged();
                Edit.RaiseCanExecuteChanged();
            }
        }

        public SongViewModel()
        {
            Songs = new ObservableCollection<Song>();
            Songs.Add(new Song()
            {
                Id = 1,
                Title = "Mama",
                Album = "Catra e Valeska So sucessos",
                Artist = "Valeska Poposuda",
                Gender = Gender.Female
            });
            Songs.Add(new Song()
            {
                Id = 1,
                Title = "Mama",
                Album = "Catra e Valeska So sucessos",
                Artist = "Valeska Poposuda",
                Gender = Gender.Female
            });

            SelectedSong = Songs.FirstOrDefault();
        }

        public class DeleteCommand : BaseCommand
        {

            public override bool CanExecute(object parameter)
            {
                SongViewModel viewModel = parameter as SongViewModel;
                return viewModel != null && viewModel.SelectedSong != null;
            }

            public override void Execute(object parameter)
            {
                var viewModel = (SongViewModel)parameter;
                viewModel.Songs.Remove(viewModel.SelectedSong);
                viewModel.SelectedSong = viewModel.Songs.FirstOrDefault();
            }
        }

        public class NewCommand : BaseCommand
        {

            public override bool CanExecute(object parameter) =>
                parameter is SongViewModel;
            


            public override void Execute(object parameter)
            {
                var viewModel = (SongViewModel)parameter;
                var song = new Song();
                var maxId = 0;
                if (viewModel.Songs.Any())
                    maxId = viewModel.Songs.Max(s => s.Id);
                song.Id = maxId;
                var sw = new SongWindow();
                sw.DataContext = song;
                sw.ShowDialog();

                if (sw.DialogResult.HasValue && sw.DialogResult.Value)
                {
                    viewModel.Songs.Add(song);
                    viewModel.SelectedSong = song;

                }
            }
        }

        public class EditCommand : BaseCommand
        {
            public override bool CanExecute(object parameter)
            {
                var viewModel = parameter as SongViewModel;
                return viewModel != null && viewModel.SelectedSong != null;
            }

            public override void Execute(object parameter)
            {
                var viewModel = (SongViewModel)parameter;
                var cloneSong = (Song)viewModel.SelectedSong.Clone();
                var sw = new SongWindow();
                sw.DataContext = cloneSong;
                sw.ShowDialog();

                if (sw.DialogResult.HasValue && sw.DialogResult.Value)
                {
                    viewModel.SelectedSong.Title = cloneSong.Title;
                    viewModel.SelectedSong.Artist = cloneSong.Artist;
                    viewModel.SelectedSong.Album = cloneSong.Album;
                    viewModel.SelectedSong.Gender = cloneSong.Gender;
                    
                }
            }
        }
    }

}
