using MembershipPortal.DTOs;
using MembershipPortal.IRepositories;
using MembershipPortal.IServices;
using MembershipPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MembershipPortal.DTOs.UserDTO;

namespace MembershipPortal.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository repository)
        {
            userRepository = repository;
        }

        public async Task<GetUserDTO> CreateUserAsync(CreateUserDTO createUserDTO)
        {
            try
            {
                var user = await userRepository.CreateAsync(new User()
                {

                    FirstName = createUserDTO.FirstName,
                    LastName = createUserDTO.LastName,
                    Email = createUserDTO.Email,
                    ContactNumber = createUserDTO.ContactNumber,
                    Password = createUserDTO.Password,
                });

                return new GetUserDTO(
                    user.Id,
                    user.FirstName,
                    user.LastName,
                    user.Email,
                    user.ContactNumber,
                    user.Password
                    );
            }
            catch (Exception ex)
            {

                //Console.WriteLine(ex.Message);
                throw;
                
            }
        }

        public async Task<bool> DeleteUserAsync(long Id)
        {
            try
            {
                var user = await userRepository.GetAsyncById(Id);

                if (user != null)
                {
                    await userRepository.DeleteAsync(user);
                    return true;

                }
               
            }
            catch (Exception ex)
            {
                // Console.WriteLine(ex.Message);
                throw;
                
            }
            return false;
        }

        public async Task<GetUserDTO> GetUserAsync(long Id)
        {
            try
            {

                var user = await userRepository.GetAsyncById(Id);
                if(user != null)
                {
                    return new GetUserDTO(
                         user.Id,
                         user.FirstName,
                         user.LastName,
                         user.Email,
                         user.ContactNumber,
                         user.Password
                         );
                }
            }
            catch (Exception)
            {

                //Console.WriteLine(ex.Message);
                throw;
            }
            return null;
        }

        public async Task<IEnumerable<GetUserDTO>> GetUsersAsync()
        {
            try
            {
                var users = await userRepository.GetAsyncAll();

                var userDto = users.Select(user => new GetUserDTO(
                             user.Id,
                             user.FirstName,
                             user.LastName,
                             user.Email,
                             user.ContactNumber,
                             user.Password
                             ));
                return userDto;
            }
            catch (Exception ex)
            {

              //  Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<GetUserDTO> UpdateUserAsync(long id, UpdateUserDTO updateUserDTO)
        {
            try
            {
                var oldUser = await userRepository.GetAsyncById(id);

                if (oldUser != null)
                {

                    oldUser.FirstName = updateUserDTO.FirstName;
                    oldUser.LastName = updateUserDTO.LastName;
                    oldUser.ContactNumber = updateUserDTO.ContactNumber;
                    oldUser.Email = updateUserDTO.Email;
                    oldUser.Password = updateUserDTO.Password;

                    var result = await userRepository.UpdateAsync(oldUser);

                    return new GetUserDTO(oldUser.Id,
                                 oldUser.FirstName,
                                 oldUser.LastName,
                                 oldUser.Email,
                                 oldUser.ContactNumber,
                                 oldUser.Password);
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred in UpdateUserAsync: {ex.Message}");
                throw;
            }
        }
    }
}
