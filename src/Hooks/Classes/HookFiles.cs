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
using ganchito.src.Hooks.AbstractClasses;

namespace ganchito.src.Hooks.Classes
{
    /// <summary>
    /// Class HookFiles(). Fornece rotinas de manipulação dos arquivos de hook do Git.
    /// </summary>
    /// <param name="operadores"></param>
    /// <param name="tipoResolucao"></param>
    /// <returns>Lista de operadores tipada.</returns>    
    class HookFiles : AbstractHookFilesBase
    {        
        private string _gitHookDirectory = $@"{Directory.GetCurrentDirectory()}\.git\hooks";
        private string _fileCommitMsg = "commit-msg";


        public string GetGitHookDirectory { get => _gitHookDirectory; }
        public string GetFileCommitMsg { get => _fileCommitMsg; }

        /// <summary>
        /// Método GitHookDirectoryExist(). Verifica se o diretorio .git\hooks existe.
        /// </summary>
        /// <returns>Valor booleano</returns>
        public override bool GitHookDirectoryExist()
        {
            bool result = false;
            
            try 
            {
                ;
                if (Directory.Exists(GetGitHookDirectory)) 
                {
                    result = true;                    
                }
                else 
                {                    
                    throw new DirectoryNotFoundException(@"O Diretório '../.git/hook' não encontrado.");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("ERROR: {0}", exception);
            }      
            
            return result;

        }

        /// <summary>
        /// Método FileExist(). Verifica se o arquivo 'commit-msg' existe.
        /// </summary>
        /// <returns>Valor booleano</returns>    
        public override bool FileExist()
        {
            bool result = false;

            try
            {                
                string path = $@"{GetGitHookDirectory}\{GetFileCommitMsg}";
                if (File.Exists(path))
                {
                    result = true;                    
                }                
            }
            catch (Exception exception)
            {
                Console.WriteLine("ERROR: {0}", exception);
            }

            return result;
        }

        /// <summary>
        /// Método FileExist(string fileName). Sem implementação.
        /// </summary>
        /// <param name="fileName"></param>        
        /// <returns>Valor booleano</returns>        
        public override bool FileExist(string fileName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Método FileRepositorieExist(). Sem implementação.
        /// </summary>
        /// <param name="fileName"></param>        
        /// <returns>Valor booleano</returns> 
        public override bool FileRepositorieExist()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Método FileRepositorieExist(string fileName). Sem implementação.
        /// </summary>
        /// <param name="fileName"></param>        
        /// <returns>Valor booleano</returns> 
        public override bool FileRepositorieExist(string fileName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Método CreateFileRepositorieStream(). Sem implementação.
        /// </summary>                
        /// <returns>String</returns> 
        public override string CreateFileRepositorieStream()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Método FileExist(string fileName). Sem implementação.
        /// </summary>
        /// <param name="repositorieURL"></param>        
        /// <returns>Valor booleano</returns> 
        public override string CreateFileRepositorieStream(string repositorieURL)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Método CreateHookFile(). Cria o arquivo de commits semânticos.
        /// </summary>        
        /// <returns>Valor booleano</returns>
        /// <remarks>Deve ser implementado em cada classe derivada.</remarks>
        public override bool CreateHookFile()
        {
            bool result = false;

            try 
            {
                if (GitHookDirectoryExist())
                {
                    

                    if (!FileExist()) 
                    {
                        string path = $@"{GetGitHookDirectory}\{GetFileCommitMsg}";

                        // Criando o arquivo de Hook
                        using (StreamWriter fileHook = new StreamWriter(path))
                        {

                            fileHook.WriteLine(@"#!/bin/sh");
                            fileHook.WriteLine(@"# ");
                            fileHook.WriteLine(@"# ==================== Ganchito Githook Tool v1.0.0 ====================");
                            fileHook.WriteLine(@"# AUTHOR: rafaelsouzars");
                            fileHook.WriteLine(@"# Date: 16/08/2025");
                            fileHook.WriteLine(@"# Github: https://github.com/rafaelsouzars");
                            fileHook.WriteLine(@"#");
                            fileHook.WriteLine(@"# Este script de hook verifica a mensagem de log de commit.");
                            fileHook.WriteLine(@"# Chamado por ""git commit"" com um argumento, o nome do arquivo");
                            fileHook.WriteLine(@"# que contém a mensagem de commit. O hook deve sair com um status");
                            fileHook.WriteLine(@"# diferente de zero após emitir uma mensagem apropriada se desejar interromper o");
                            fileHook.WriteLine(@"# commit. O hook tem permissão para editar o arquivo de mensagem de commit.");
                            fileHook.WriteLine(@"#");
                            fileHook.WriteLine(@"# Para habilitar este hook, renomeie este arquivo .sh para ""commit-msg"" (sem a extensão),");
                            fileHook.WriteLine(@"# copie e substitua o arquivo (de mesmo nome) na pasta .git/hooks que fica dentro da pasta do");
                            fileHook.WriteLine(@"# seu projeto.");
                            fileHook.WriteLine(@"");
                            fileHook.WriteLine(@"# Variáveis com os códicos de escape ASCII referentes as cores do foreground");
                            fileHook.WriteLine(@"BLACK=""\033[0;30m""");
                            fileHook.WriteLine(@"RED=""\033[0;31m""");
                            fileHook.WriteLine(@"GREEN=""\033[0;32m""");
                            fileHook.WriteLine(@"YELLOW=""\033[0;93m""");
                            fileHook.WriteLine(@"BLUE=""\033[0;34m""");
                            fileHook.WriteLine(@"WHITE=""\033[1;37m""");
                            fileHook.WriteLine(@"DEFAULT=""\033[0m""");
                            fileHook.WriteLine(@"");
                            fileHook.WriteLine(@"# Variáveis com os códicos de escape ASCII referentes as cores do background");
                            fileHook.WriteLine(@"BK_BLACK=""\033[40m""");
                            fileHook.WriteLine(@"BK_RED=""\033[41m""");
                            fileHook.WriteLine(@"BK_GREEN=""\033[42m""");
                            fileHook.WriteLine(@"BK_YELLOW=""\033[103m""");
                            fileHook.WriteLine(@"BK_BLUE=""\033[44m""");
                            fileHook.WriteLine(@"BK_DEFAULT=""\033[0m""");
                            fileHook.WriteLine(@"");
                            fileHook.WriteLine(@"# Variável com o arquivo da menssagem do commit (provided by Git).");
                            fileHook.WriteLine(@"COMMIT_MSG_FILE=$1");
                            fileHook.WriteLine(@"");
                            fileHook.WriteLine(@"# Lê a mensagem do commit que esta no arquivo.");
                            fileHook.WriteLine(@"COMMIT_MSG=$(cat ""$COMMIT_MSG_FILE"")");
                            fileHook.WriteLine(@"");
                            fileHook.WriteLine(@"# Expressão regular de padronização das mensagens do commit");
                            fileHook.WriteLine(@"COMMIT_REGEX='^(:(tada|sparkles|bug|lipstick|wrench|truck|bricks|bulb|books|ok_hand|recycler|broom|boom|zap|package|rocket|white_check_mark|heavy_plus_sign|heavy_minus_sign|card_file_box|test_tube|iphone|pencil|label|lock|mag|goal_net|construction|wheelchair|dizzy|arrow_up|arrow_down|wastebasket):\s)?(build|ci|docs|feat|fix|perf|refactor|style|test|chore|revert|wip|release|hotfix|rollback|raw|cleanup|remove|init)(\([a-zA-Z0-9_.-]+\))?(!)?: .+$'");
                            fileHook.WriteLine(@"#TYPE_COMMIT_REGEX=''");
                            fileHook.WriteLine(@"");
                            fileHook.WriteLine(@"# Testa a mensagem do commit com o PATTERN REGEX");
                            fileHook.WriteLine(@"if [ ""$(egrep -e ""$COMMIT_REGEX"" ""$COMMIT_MSG_FILE"")"" ]; then");
                            fileHook.WriteLine(@"	echo >&2");
                            fileHook.WriteLine(@"	echo >&2 -e ""${WHITE}${BK_BLUE}[==================== Ganchito Githook Tool v1.0.0 ====================]${DEFAULT}""");
                            fileHook.WriteLine(@"	echo >&2 -e ""${BK_GREEN}SUCCESS: O commit foi realizado com sucesso.${DEFAULT}""");
                            fileHook.WriteLine(@"	echo >&2");
                            fileHook.WriteLine(@"	echo >&2 -e ""${GREEN}(OK) COMMIT => ${BLACK}${BK_GREEN}'${COMMIT_MSG}'${DEFAULT}""");
                            fileHook.WriteLine(@"	echo");
                            fileHook.WriteLine(@"	echo >&2 -e ""${BK_BLUE}Programmer: https://github.com/rafaelsouzars${DEFAULT}""");
                            fileHook.WriteLine(@"	echo >&2 -e ""${WHITE}${BK_BLUE}[==================== Ganchito Githook Tool v1.0.0 ====================]${DEFAULT}""");
                            fileHook.WriteLine(@"	echo >&2 -e ""${GREEN}[=== FINISHED ===]${DEFAULT}""");
                            fileHook.WriteLine(@"	exit 0");
                            fileHook.WriteLine(@"else");
                            fileHook.WriteLine(@"	echo >&2 -e ""${WHITE}${BK_RED}[==================== Ganchito Githook Tool v1.0.0 ====================]${DEFAULT}""");
                            fileHook.WriteLine(@"	echo >&2 -e ""${BLACK}${BK_RED}ERRO: A mensagem de commit não segue o formato do conventional Commits.${DEFAULT}""");
                            fileHook.WriteLine(@"	echo >&2");
                            fileHook.WriteLine(@"	echo >&2 -e ""${RED}(!) COMMIT => ${BLACK}${BK_RED}'${COMMIT_MSG}'${DEFAULT}""");
                            fileHook.WriteLine(@"	echo >&2");
                            fileHook.WriteLine(@"	echo >&2 -e ""${BLACK}${BK_YELLOW}O formato correto da mensagem de commit é obrigatório:${DEFAULT}""");
                            fileHook.WriteLine(@"	echo >&2 -e ""  <:emoji opcional:> <tipo>(<escopo opcional>): <descrição>""");
                            fileHook.WriteLine(@"	echo >&2");
                            fileHook.WriteLine(@"	echo >&2 -e ""${BK_GREEN}Os tipos válidos são:${DEFAULT}""");
                            fileHook.WriteLine(@"	echo >&2 -e ""${GREEN}  feat:${DEFAULT}     Uma nova funcionalidade.""");
                            fileHook.WriteLine(@"	echo >&2 -e ""${GREEN}  fix:${DEFAULT}      Correção de um bug.""");
                            fileHook.WriteLine(@"	echo >&2 -e ""${GREEN}  docs:${DEFAULT}     Alterações na documentação.""");
                            fileHook.WriteLine(@"	echo >&2 -e ""${GREEN}  style:${DEFAULT}    Alterações de estilo de código (formatação, ponto-e-vírgula ausente, etc.).""");
                            fileHook.WriteLine(@"	echo >&2 -e ""${GREEN}  refactor:${DEFAULT} Refatoração de código (nem corrige bug nem adiciona funcionalidade).""");
                            fileHook.WriteLine(@"	echo >&2 -e ""${GREEN}  test:${DEFAULT}     Adicionar ou atualizar testes.""");
                            fileHook.WriteLine(@"	echo >&2 -e ""${GREEN}  chore:${DEFAULT}    Tarefas rotineiras como atualização de dependências ou ferramentas de build.""");
                            fileHook.WriteLine(@"	echo >&2 -e ""${GREEN}  build:${DEFAULT}    Alterações que afetam o sistema de build ou dependências externas.""");
                            fileHook.WriteLine(@"	echo >&2 -e ""${GREEN}  ci:${DEFAULT}       Alterações nos arquivos de configuração de CI ou scripts.""");
                            fileHook.WriteLine(@"	echo >&2 -e ""${GREEN}  perf:${DEFAULT}     Melhorias de desempenho.""");
                            fileHook.WriteLine(@"	echo >&2 -e ""${GREEN}  revert:${DEFAULT}   Reverter um commit anterior.""");
                            fileHook.WriteLine(@"	echo >&2");
                            fileHook.WriteLine(@"	echo >&2 -e ""${BK_GREEN}Emojis:${DEFAULT}""");
                            fileHook.WriteLine(@"	echo >&2 -e ""${GREEN}tada|sparklers|bug|lipstick|wrench|truck|bricks|bulb|books|ok_hand|recycler|broom|boom|zap""");
                            fileHook.WriteLine(@"	echo >&2 -e ""package|rocket|white_check_mark|heavy_plus_sign|heavy_minus_sign|card_file_box|test_tube""");
                            fileHook.WriteLine(@"	echo >&2 -e ""iphone|pencil|label|lock|mag|goal_net|construction|wheelchair|dizzy|arrow_up|arrow_down|wastedbasket${DEFAULT}""");
                            fileHook.WriteLine(@"	echo >&2");
                            fileHook.WriteLine(@"	echo >&2 -e ""Exemplos:""");
                            fileHook.WriteLine(@"	echo >&2 -e ""  :tada: feat: Primeira feature""");
                            fileHook.WriteLine(@"	echo >&2 -e ""  feat(auth): adicionar funcionalidade de login""");
                            fileHook.WriteLine(@"	echo >&2 -e ""  fix(api)!: resolver problema de timeout""");
                            fileHook.WriteLine(@"	echo >&2 -e ""  docs(readme): atualizar instruções de instalação""");
                            fileHook.WriteLine(@"	echo");
                            fileHook.WriteLine(@"	echo >&2 -e ""${BK_RED}Programmer: https://github.com/rafaelsouzars${DEFAULT}""");
                            fileHook.WriteLine(@"	echo >&2 -e ""${WHITE}${BK_RED}[==================== Ganchito Githook Tool v1.0.0 ====================]${DEFAULT}""");
                            fileHook.WriteLine(@"	echo >&2");
                            fileHook.WriteLine(@"	exit 1");
                            fileHook.WriteLine(@"fi");
                        }

                        Console.WriteLine(@" Success: Ganchito Semantic Commit Message Hook Create.");

                        result = true;
                    }
                    else 
                    {
                        Console.WriteLine(" O hook já foi criado.\n");
                    }
                    
                    
                }
            }
            catch (Exception exception) 
            {
                Console.WriteLine("ERROR: {0}", exception);
            }           

            return result;
        }

        /// <summary>
        /// Método CreateHookFile(string fileStream). Sem implementação.
        /// </summary>
        /// <param name="fileStream"></param>        
        /// <returns>Valor booleano</returns> 
        public override bool CreateHookFile(string fileStream)
        {
            throw new NotImplementedException();
        }
    }
}
