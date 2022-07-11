﻿
using BackendPartUpdated.DataManagment.Commands;
using BackendPartUpdated.DataManagment.Dto;
using BackendPartUpdated.DataManagment.Queries;
using MediatR;

namespace BackendPartUpdated.API.Services
{
    public class UserServices : IUserService
    {
        
        private readonly IMediator _mediator;

        public UserServices(IMediator mediator)
        {
            _mediator = mediator;
        }
        

        public List<UserEntityDto> userEntityConverter(List<BackendPartUpdated.DataManagment.Entities.UserEntity> userList)
        {
            var convertedListUser = new List<UserEntityDto>();
            foreach (BackendPartUpdated.DataManagment.Entities.UserEntity userEntity in userList)
            {
                convertedListUser.Add(new UserEntityDto(userEntity.Id, userEntity.Username, userEntity.Email, userEntity.Gender));
            }

            return convertedListUser;
        }


        public async Task<List<UserEntityDto>> EditUser(UserEntityDto userEntity)
        {
            var convertedUser = new BackendPartUpdated.DataManagment.Entities.UserEntity(userEntity.Id, userEntity.Username, userEntity.Email, userEntity.Gender);
            var userList = await _mediator.Send(new EditUserCommand(convertedUser));
            return userEntityConverter(userList);
        }
    }
}
