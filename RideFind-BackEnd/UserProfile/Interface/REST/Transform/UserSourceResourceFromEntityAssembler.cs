using RideFind_BackEnd.UserProfile.Domain.Model.Aggregates;
using RideFind_BackEnd.UserProfile.Interface.REST.Resource;

namespace RideFind_BackEnd.UserProfile.Interface.REST.Transform;

public static class UserSourceResourceFromEntityAssembler
{
    public static UserSourceResource toResourceFromEntity(UserSource entity)=>
        new UserSourceResource(entity.Id, entity.Name, entity.Surname, entity.Email, entity.Password, entity.Phone, entity.Address, entity.City, entity.Country, entity.UserId, entity.Dni);
}