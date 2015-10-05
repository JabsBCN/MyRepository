using System.Collections.Generic;
using System.Threading;
using System.Windows.Data;
using DataAccess.BackEnd;
using DataAccess.MongoDB.Client.WPF.ViewModels;

namespace DataAccess.Client.WPF
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly ArtistsBL artistsBL;

        public MainWindowViewModel()
        {
            var myThreat = new Thread(new ThreadStart(ShowArtistsData));

            myThreat.Start();
        }

        private void ShowArtistsData()
        {
            IList<Artists> artistList = new ArtistsBL().GetAll();

            this.ArtistsView = new CollectionView(artistList);
        }

        private CollectionView _artistsView;

        public CollectionView ArtistsView
        {
            get { return _artistsView; }
            set
            {
                _artistsView = value;
                // OnPropertyChanged("ArtistsView");
            }
        }
    }
}
