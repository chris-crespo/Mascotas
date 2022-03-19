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
        Members.RemoveAll(member => member.ID.Equals(m.ID));
        MemberRepo.Save(Members);
    }

    public void AddPet(Pet p)
    {
        Pets.Add(p);
        PetRepo.Save(Pets);
    }

    public void RemovePet(Pet p)
    {
        Pets.RemoveAll(pet => pet.ID.Equals(p.ID));
        PetRepo.Save(Pets);
    }
}
