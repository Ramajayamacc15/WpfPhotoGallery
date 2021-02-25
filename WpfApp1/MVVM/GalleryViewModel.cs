using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Data;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using WpfApp1.DAL;

namespace WpfApp1
{
    public class GalleryViewModel : INotifyPropertyChanged
    {
        public ICollectionView GalleryPhotos { get; set; }
        public ICommand AddNewPhotoCommand { get; set; }
        public ICommand SortByCommand { get; set; }
        public string NewPhotoName
        {
            get { return _newPhotoName; }
            set { _newPhotoName = value; OnPropertyChanged(nameof(NewPhotoName)); }
        }
        public string NewPhotoURL
        {
            get { return _newPhotoURL; }
            set { _newPhotoURL = value; OnPropertyChanged(nameof(NewPhotoURL)); }
        }

        private IGalleryService _galleryService;
        private List<PhotoModel> _photos;
        private string _newPhotoName;
        private string _newPhotoURL;
        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                OnPropertyChanged(nameof(SearchText));
                GalleryPhotos.Refresh();
            }
        }
        public GalleryViewModel()
        {
            _galleryService = new GalleryService();
            LoadGallery();
            GalleryPhotos = CollectionViewSource.GetDefaultView(_photos);
            GalleryPhotos.Filter = GallerySearch;
            AddNewPhotoCommand = new DelegateCommand(AddNewPhoto, CanAddNewPhotoExecute);
            SortByCommand = new DelegateCommand(SortGalleryData);
        }

        private void LoadGallery()
        {
            _photos = _galleryService.GetGallery("Gallery-Nature").Select(p => Convert(p)).ToList();
        }

        private bool GallerySearch(object photo)
        {
            if (string.IsNullOrEmpty(_searchText))
                return true;
            return ((PhotoModel)photo).Name.Contains(_searchText);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void SortGalleryData(object parameter)
        {
            if (parameter is null)
                return;
            GalleryPhotos.SortDescriptions.Clear();
            if(parameter.ToString().Equals("Latest"))
                GalleryPhotos.SortDescriptions.Add(new SortDescription("AddedTime", ListSortDirection.Descending));
            else
                GalleryPhotos.SortDescriptions.Add(new SortDescription("AddedTime", ListSortDirection.Ascending));
        }
        private void AddNewPhoto(object parameter)
        {
            _photos.Add(new PhotoModel { Name = NewPhotoName, SourceURL = NewPhotoURL, AddedTime = DateTime.Now });
            GalleryPhotos.Refresh();
        }
        private bool CanAddNewPhotoExecute(object parameter)
        {
            return !string.IsNullOrEmpty(NewPhotoName) && !string.IsNullOrEmpty(NewPhotoURL);
        }

        private PhotoModel Convert(PhotoDto p)
        {
            return new PhotoModel
            {
                Name = p.Name,
                SourceURL = p.SourceURL,
                AddedTime = p.AddedDate
            };
        }
    }
}
