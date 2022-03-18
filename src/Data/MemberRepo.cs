using Mascotas.Models;

namespace Mascotas.Data;

public class MemberRepo : IRepository<Member>
{
    string _file = "members.csv";

    string stringify(Member member)

    Member parseMember(string line)
    {
        var fields = line.Split(",");
        return new Member
        {

    }

    public void Save(List<Member> members)
    {
        var header = "ID,Nombre,Sexo";
        var data   = new List<string>() { header };
        members.ForEach(member => data.add(member.ToString()));
        File.WriteAllLines(_file, data);
    }

    public List<Member> Read()
        => File.ReadAllLines(_file)
            .Skip(1)
            .Where(line => line.Length > 0)
            .Select(parseMember)
            .ToList();
