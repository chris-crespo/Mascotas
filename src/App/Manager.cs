using Mascotas.Models;
using Mascotas.Data;

namespace Mascotas;

public class Manager
{
    PetRepo    PetRepo;
    MemberRepo MemberRepo; 
    SpecieRepo SpecieRepo;

    public List<Member> Members { get; }
    public List<Pet>    Pets    { get; }
    public List<Specie> Species { get; }

    public Manager(MemberRepo memberRepo, PetRepo petRepo, SpecieRepo specieRepo)
    {
        MemberRepo = memberRepo;
        PetRepo    = petRepo;
        SpecieRepo = specieRepo;

        Members = memberRepo.Read();
        Species = specieRepo.Read();
        Pets    = petRepo.Read();
    }

    public void AddMember(Member m) 
    {
        Members.Add(m);
        MemberRepo.Save(Members);
    }

    public void RemoveMember(Member m)
    {
        Members.Remove(m);
        Pets.RemoveAll(pet => pet.MemberID.Equals(m.ID));
        MemberRepo.Save(Members);
        PetRepo.Save(Pets);
    }

    public void AddPet(Pet p)
    {
        Pets.Add(p);
        PetRepo.Save(Pets);
    }

    public void RemovePet(Guid id)
    {
        Pets.RemoveAll(p => p.ID.Equals(id));
        PetRepo.Save(Pets);
    }

    public void AddSpecie(Specie s)
    {
        Species.Add(s);
        SpecieRepo.Save(Species);
    }

    public void RemoveSpecie(Specie s)
    {
        Species.Remove(s);
        SpecieRepo.Save(Species);
    }

    public List<Pet> GetPetsOfSpecie(Specie s)
        => Pets.Where(pet => pet.SpecieID.Equals(s.ID)).ToList();

    public List<Pet> GetAvailablePets()
        => Pets.Where(pet => pet.MemberID == null).ToList();

    public void ChangePetOwner(Pet pet, Member member)
    {
        pet.MemberID = member.ID;
        PetRepo.Save(Pets);
    }
}
