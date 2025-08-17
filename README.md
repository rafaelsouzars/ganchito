<div align="center"><img width="200" height="200" alt="ganchito" src="https://github.com/user-attachments/assets/6eac7a2f-5378-48c5-a852-e9ac4bdcae31" /></div>

# Ganchito v1.0.1

![Version](https://img.shields.io/badge/version-1.0.0-green) ![Status](https://img.shields.io/badge/status-development-yellow) ![Github Release](https://img.shields.io/github/v/release/rafaelsouzars/ganchito)

Utilitario de git hooks.

### Notas da versão
- Correção de erros de ortografia no README 

## Introdução
O _Ganchito_ facilita a criação do arquivos commit-msg adicionando regras de commits semânticos.

## Instalação
Pode ser via [Scoop](https://scoop.sh)
1. Instale o Scoop
```powershell
Set-ExecutionPolicy -ExecutionPolicy RemoteSigned -Scope CurrentUser
Invoke-RestMethod -Uri https://get.scoop.sh | Invoke-Expression
```
2. Instale o Ganchito
```powershell
scoop bucket add https://github.com/rafaelsouzars/Bucket
scoop install ganchito
```
Ou pode ser feita a instalação manual baixando os binarios no repositorio clicando [aqui](https://github.com/rafaelsouzars/ganchito/releases)
1. Baixe o binário
```
https://github.com/rafaelsouzars/ganchito/releases
```

## Tutorial
Para criar o hook de commits semânticos, abra o terminal no repositório local do projeto e digite o commando:
```powershell
C:\user\documents\my-project> ganchito commit
```
_Obs: Este procedimento deve ser feito depois do git init._

Para ver a ajuda do aplicativo basta digitar:
```powershell
C:\user\documents\my-project> ganchito help
```
----------------------------------
<div align="center">

#### [Github: rafaelsouzars](https://rafaelsouzars.github.io)

</div>
