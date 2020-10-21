using System;
using System.Collections.Generic;
using System.Data;
using AmaZen.Models;
using AmaZen.Repositories;

namespace AmaZen.Services
{
  public class ProfilesService
  {
    private readonly ProfilesRepository _repo;
    public ProfilesService(ProfilesRepository repo)
    {
      _repo = repo;
    }

    internal string GetProfileEmailById(string id)
    {
      return _repo.GetById(id).Email;
    }
    internal Profile GetProfileByEmail(string email)
    {
      return _repo.GetByEmail(email);
    }
    internal Profile GetOrCreateProfile(Profile userInfo)
    {
      Profile profile = _repo.GetByEmail(userInfo.Email);
      if (profile == null)
      {
        return _repo.Create(userInfo);
      }
      return profile;
    }

    internal Profile Edit(Profile editData, string userEmail)
    {
      Profile original = GetProfileByEmail(userEmail);
      original.Name = editData.Name.Length > 0 ? editData.Name : original.Name;
      original.Picture = editData.Picture.Length > 0 ? editData.Picture : original.Picture;
      return _repo.Edit(original);
    }
  }
}