using AutoMapper;
using ContactManagement.DataLayer;
using ContactManagement.Dtos;
using ContactManagement.Entities;
using ContactManagement.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagement.Services.Implementations
{
    public class ContactService: IContactService
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Contact> _asyncRepository;
        private readonly IAsyncRepository<PhoneNumber> _phoneRepository;

        public ContactService(
            IAsyncRepository<Contact> asyncRepository, 
            IMapper mapper,
            IAsyncRepository<PhoneNumber> phoneRepository)
        {
            _mapper = mapper;
            _asyncRepository = asyncRepository;
            _phoneRepository = phoneRepository;
        }

        public async Task Delete(int id)
        {
            Contact contact = await _asyncRepository.GetByIdAsync(id, "PhoneNumbers");
            if (contact == null)
            {
                throw new Exception("Contact is present in the database");
            }
            _asyncRepository.Delete(contact);
            await _asyncRepository.SaveAsync();
        }

        public async Task<int> Create(ContactDto contactDto)
        {
            Contact contact = _mapper.Map<Contact>(contactDto);
            if (contact.Id != 0)
            {
                throw new Exception("Invalid request for create contact");
            }
            contact.UpdatedOn = contact.CreatedOn = DateTime.Now;
            contact.IsActive = true;
            foreach (var numbers in contact.PhoneNumbers)
            {
                numbers.UpdatedOn = numbers.CreatedOn = DateTime.Now;
                numbers.IsActive = true;
            }
            await _asyncRepository.AddAsync(contact);
            await _asyncRepository.SaveAsync();
            return contact.Id;
        }

        public async Task<IEnumerable<ContactDto>> GetAll()
        {
            IEnumerable<Contact> contacts = await _asyncRepository.ListAsync("PhoneNumbers");
            IEnumerable<ContactDto> contactDtos = _mapper.Map<IEnumerable<ContactDto>>(contacts);
            return contactDtos;
        }

        public async Task<ContactDto> GetById(int id)
        {
            Contact contact = await _asyncRepository.GetByIdAsync(id, "PhoneNumbers");
            if (contact == null)
            {
                throw new Exception("Contact is present in the database");
            }
            return _mapper.Map<ContactDto>(contact);
        }

        public async Task<int> GetById(ContactDto contactDto)
        {
            Contact contact = _mapper.Map<Contact>(contactDto);
            contact.IsActive = true;
            contact.CreatedOn = contact.UpdatedOn = DateTime.Now;
            foreach(var phoneNumber in contact.PhoneNumbers)
            {
                phoneNumber.IsActive = true;
                phoneNumber.CreatedOn = phoneNumber.UpdatedOn = DateTime.Now;
            }
            int i = await _asyncRepository.AddAsync(contact);
            await _asyncRepository.SaveAsync();
            return i;
        }

        public async Task<int> Update(ContactDto contactDto)
        {
            Contact contact = _mapper.Map<Contact>(contactDto);
            Contact contactFromDb = await _asyncRepository.GetByIdAsync(contactDto.Id, "PhoneNumbers");
            if (contactFromDb == null)
            {
                throw new Exception("Contact not present in the database");
            }
            contactFromDb.FirstName = contactDto.FirstName;
            contactFromDb.LastName = contactDto.LastName;
            contactFromDb.UpdatedOn = DateTime.Now;
            foreach(var numbers in contactFromDb.PhoneNumbers)
            {
                _phoneRepository.Delete(numbers);
            }
            contactFromDb.PhoneNumbers = contact.PhoneNumbers;
            foreach (var numbers in contactFromDb.PhoneNumbers)
            {
                numbers.UpdatedOn = numbers.CreatedOn = DateTime.Now;
                numbers.IsActive = true;
            }
            _asyncRepository.Update(contactFromDb);
            await _asyncRepository.SaveAsync();
            return contactFromDb.Id;
        }
    }
}
