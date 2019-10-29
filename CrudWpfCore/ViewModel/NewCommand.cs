using CrudWpfCore.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrudWpfCore.ViewModel
{
    public class NewCommand : BaseCommand
    {

        public override bool CanExecute(object parameter) =>
            parameter is SongViewModel;



        public override void Execute(object parameter)
        {
            var viewModel = (SongViewModel)parameter;
            var song = new SongDb();


            var sw = new SongWindow();
            sw.DataContext = song;
            sw.ShowDialog();

            if (sw.DialogResult.HasValue && sw.DialogResult.Value)
            {
                using (var db = new SongDbContext())
                {
                    db.Songs.Add(song);
                    db.SaveChanges();
                }
                viewModel.Songs.Add(SongViewModel.SongConverter(song));
                viewModel.SelectedSong = SongViewModel.SongConverter(song);

            }
        }
    }
}
