using CrudWpfCore.Data;
using CrudWpfCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrudWpfCore.ViewModel
{
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
                viewModel.SelectedSong.Genre = cloneSong.Genre;

                using (var db = new SongDbContext())
                {
                    var song = db.Songs.First(s => s.Id == cloneSong.Id);
                    song.Title = cloneSong.Title;
                    song.Artist = cloneSong.Artist;
                    song.Album = cloneSong.Album;
                    song.Genre = cloneSong.Genre;

                    db.SaveChanges();
                }

            }
        }
    }
}
