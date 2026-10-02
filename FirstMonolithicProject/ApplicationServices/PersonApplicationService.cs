using FirstMonolithicProject.ApplicationServices.Dtos.PersonDtos;
using FirstMonolithicProject.ApplicationServices.Services.Contracts;
using FirstMonolithicProject.Models.Services.Contracts;
using Microsoft.AspNetCore.Http.HttpResults;

namespace FirstMonolithicProject.ApplicationServices
{
    public class PersonApplicationService:IPersonApplicationService
    {
        private readonly IPersonRepository _personRepository;
        #region [- ctor -]
        public PersonApplicationService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        #endregion

        #region [- Update() -]
        public async Task Put(UpdatePersonDto updatePersonDto)
        {
            var updatePerson = new Models.DomainModels.PersonAggregates.Person()
            {
                Id = updatePersonDto.Id,
                FirstName = updatePersonDto.FirstName,
                LastName = updatePersonDto.LastName,
                Age = updatePersonDto.Age,
            };
            await _personRepository.Update(updatePerson);
        }

        #endregion

        #region [- Delete() -]
        public async Task Delete(DeletePersonDto deletePersonDto)
        {
            var deletePerson = new Models.DomainModels.PersonAggregates.Person()
            {  
                Id = deletePersonDto.Id,
                FirstName = deletePersonDto.FirstName,
                LastName = deletePersonDto.LastName,
                Age = deletePersonDto.Age
            };
            await _personRepository.Delete(deletePerson);
            
        }
        #endregion

        #region [- Post() -]
        public async Task Post(PostPersonDto postPersonDto)
        {
            var person = new Models.DomainModels.PersonAggregates.Person()
            {
                Id = postPersonDto.Id,
                FirstName = postPersonDto.FirstName,
                LastName = postPersonDto.LastName,
                Age = postPersonDto.Age,
            };
            await _personRepository.Insert(person);
        }
        #endregion

        #region [- GetAllPerson() -]
        public async Task<List<GetPersonDto>> GetAllPerson()
        {
            var persons = await _personRepository.SelectAll();
            var getPersonDtos = new List<GetPersonDto>();
            foreach (var person in persons)
            {
                var getPersonDto = new GetPersonDto()
                {
                    Id = person.Id,
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    Age= person.Age,
                };
                getPersonDtos.Add(getPersonDto);
            }
            return getPersonDtos;
        }
        #endregion

        #region [- GetById() -]
        public async Task<GetPersonDtoById> GetById(int Id)
        {
            var person = await _personRepository.SelectById(Id);
            if (person == null)
            {
                return null;
            }
            var getPersonDto = new GetPersonDtoById()
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Age = person.Age
            };
            return getPersonDto;
        } 
        #endregion

    }
}
