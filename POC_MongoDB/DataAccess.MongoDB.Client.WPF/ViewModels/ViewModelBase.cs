using System.ComponentModel;
using System.Runtime.CompilerServices;
using DataAccess.MongoDB.Client.WPF.Annotations;

namespace DataAccess.MongoDB.Client.WPF.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            };
        }
    }
}
