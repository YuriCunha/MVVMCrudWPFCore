using CrudWpfCore.Data;
using CrudWpfCore.Models;
using Microsoft.EntityFrameworkCore;
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
            using (var db = new SongDbContext())              
                foreach (var song in db.Songs)
                    Songs.Add(SongConverter(song));

            SelectedSong = Songs.FirstOrDefault();
        }

        public static Song SongConverter(SongDb songDb) =>       
             new Song
             {
                Id = songDb.Id,
                Title = songDb.Title,
                Artist = songDb.Artist,
                Album = songDb.Album,
                Genre = songDb.Genre,
             };
        

    }

}
