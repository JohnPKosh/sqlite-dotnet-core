namespace SqliteConsole.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IDocService
{
    void AddDoc(string name);
    void GetDocs();
}
