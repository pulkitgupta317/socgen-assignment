using ContactManagement.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagement.Services.Contracts
{
    public interface IContactService
    {
        Task Delete(int id);

        Task<IEnumerable<ContactDto>> GetAll();

        Task<ContactDto> GetById(int id);

        Task<int> Update(ContactDto contactDto);

        Task<int> Create(ContactDto contactDto);
    }
}
