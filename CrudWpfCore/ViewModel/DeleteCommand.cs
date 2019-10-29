using CrudWpfCore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrudWpfCore.ViewModel
{
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
            using (var db = new SongDbContext())
            {
                db.Songs.Remove(db.Songs.First(s => s.Id == viewModel.SelectedSong.Id));
                db.SaveChanges();
            }
            viewModel.Songs.Remove(viewModel.SelectedSong);
            viewModel.SelectedSong = viewModel.Songs.FirstOrDefault();
        }
    }



}
