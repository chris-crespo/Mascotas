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

    public Manager(MemberRepo memberRepo, PetRepo petRepo, SpecieRepe specieRepo)
    {
        MemberRepo = memberRepo;
        PetRepo    = petRepo;
        SpecieRepo = specieRepo;

        Members = memberRepo.Read();
        Species = specieRepo.Read();

        petRepo.Members = Members;
        petRepo.Species = Species;
        Pets = petRepo.Read();
    }

    public void AddMember(Member m) 
    {
        Members.Add(m);
        MemberRepo.Save(Members);
    }
}
