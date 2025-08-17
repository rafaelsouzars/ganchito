/*
 * 
 * Ganchito
 * Version: v1.0.0
 * Description: Utilitário de git hooks
 * Author: rafaelsouzars
 * Github: https://github.com/rafaelsouzars
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace ganchito.src.Hooks.AbstractClasses
{
    abstract public class AbstractHookFilesBase
    {

        abstract public bool GitHookDirectoryExist();

        abstract public bool FileExist();

        abstract public bool FileExist(string fileName);

        abstract public bool FileRepositorieExist();

        abstract public bool FileRepositorieExist(string fileName);

        abstract public string CreateFileRepositorieStream();

        abstract public string CreateFileRepositorieStream(string repositorieURL);

        abstract public bool CreateHookFile();

        abstract public bool CreateHookFile(string fileStream);

    }
}
