using System;
using System.Collections.Generic;
using System.Text;

namespace CrudWpfCore.Models
{
    public class Song : BaseNotifyPropertyChanged, ICloneable
    {
        private int _id;
        public int Id { 
            get => _id;
            set => SetField(ref _id, value);
            
        }
        private string _title;
        public string Title
        {
            get => _title;
            set => SetField(ref _title, value);

        }
        private string _artist;
        public string Artist
        {
            get => _artist;
            set => SetField(ref _artist, value);

        }
        private string _album;
        public string Album
        {
            get => _album;
            set => SetField(ref _album, value);

        }
        private string _genre;
        public string Genre 
        {
            get => _genre;
            set => SetField(ref _genre, value);
        }

        public object Clone() =>
            this.MemberwiseClone();
        
            
        
    }
}
