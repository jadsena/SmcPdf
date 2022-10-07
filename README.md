# Merge Pdf

Ferramenta para realizar o merge de documentos no formato Pdf.

## Pré-requisitos

Instalação do runtime [.Net 6.0](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)

## Instalação

Executar o comando no prompt de comando:

```prompt
dotnet tool install --global SmcPdf
```

## Utilização

Executar o comando no prompt de comando:

```prompt
mergepdf <Novo.pdf> <Merge1.pdf> <Merge2.pdf> <MergeN.pdf>
```

Onde:

| Parâmetro | Descrição |
| --- | --- |
| Novo.pdf | Nome arquivo que será gerado no final do processo, precisa da extenção .pdf |
| Merge1.pdf | Primeira arquivo a ser juntado no novo arquivo |
| Merge2.pdf | Segundo arquivo a ser juntado no novo arquivo |
| MergeN.pdf | Quantos arquivo tiverem para serem juntados |

> São obrigatórios os 3 primeiros parâmetros, tendo assim o nome do novo arquivo e dois arquivos para o merge

## Links úteis

[Utilizando ferramentas .Net](https://learn.microsoft.com/pt-br/dotnet/core/tools/global-tools-how-to-use)
