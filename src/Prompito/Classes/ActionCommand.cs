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
using System.Reflection;
using ganchito.Prompito.AbstractClasses;

namespace ganchito.Prompito.Classes
{
    class ActionCommand : AbstractActionCommandBase
    {
        /// <summary>
        /// Método Run(). Executa o código implementado no escopo quando o comando for executado.
        /// </summary>       
        /// <remarks>Deve ser implementado em cada classe derivada.</remarks>
        override public void Run() 
        {
            
        }

        /// <summary>
        /// Método Run(). Executa o código implementado no escopo quando o comando for executado.
        /// </summary>
        /// <param name="args">Recebe os argumentos do console</param>        
        /// <remarks>Deve ser implementado em cada classe derivada.</remarks>
        override public void Run(string[] args)
        {

        }        


    }
}
