using FirstMonolithicProject.ApplicationServices.Dtos.PersonDtos;
using FirstMonolithicProject.Models.DomainModels.PersonAggregates;

namespace FirstMonolithicProject.Models.Services.Contracts
{
    public interface IPersonRepository
    {
        #region [- Update() -]
        Task Update(Person person);
        #endregion

        #region [- Delete() -]
        Task Delete(Person person);
        #endregion

        #region [- Insert() -]
        Task Insert(Person person);
        #endregion

        #region [- SelectAll() -]
        Task<List<Person>> SelectAll();

        #endregion

        #region [- SelectById() -]
        Task<Person> SelectById(int Id);

        #endregion 
    }

}
