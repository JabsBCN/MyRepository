using System.Collections.Generic;

namespace DataAccess.BackEnd.Business
{
    public interface IArtistsBL
    {
        Artists GetById(string id);

        IList<Artists> GetAll();

        IList<Artists> GetFiltered(IList<QueryInfo> query);
    }
}
