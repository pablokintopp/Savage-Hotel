using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savage_Hotel_System.Class
{
    class Funcoes
    {
        public Funcoes()
        {

        }

        public int verificatelefone(String entrada)
        {
            //Verifica Telefone
            //Se tudo estiver ok, retorna 0
            //Caso contrário retorna 1
            //Se o tamanho da entrada for diferente de 10 retorna 2 (Casas incompletas ou maior que a necessária)
            int tam = entrada.Length;
            for (int i = 0; i < tam; i++)
            {
                if (entrada[i] > 47 && entrada[i] < 58)
                {
                    //cout<<entrada[i]<<endl;
                }
                else
                {
                    //cout<<entrada[i];
                    //cout<<" caracter invalido"<<endl;
                    return 1;
                }
            }
            if (tam != 10)
            {
                return 2;
            }
            return 0;
        }

        public int verificanome(String entrada)
        {
            //Verifica Nome
            //Se tudo estiver ok, retorna 0
            //Caso contrário retorna 2 (Tamanho Mínino 1)
            //Caso contrário retorna 1 (caracteres Inválidos)
            int tam = entrada.Length;
            for (int i = 0; i < tam; i++)
            {
                if (((entrada[i] > 64 && entrada[i] < 91) || (entrada[i] > 96 && entrada[i] < 123)) || (entrada[i] == 32))
                {
                    //cout<<entrada[i];
                }
                else
                {
                    //cout<<entrada[i];
                    //cout<<" caracter invalido"<<endl;
                    return 1;
                }
            }
            if (tam <= 1)
            {
                return 2;
            }
            return 0;
        }

        public int verificacpf(String entrada)
        {
            //Verifica CPF
            //Se tudo estiver ok, retorna 0
            //Caso contrário retorna 1
            //Se o tamanho da entrada for diferente de 11 retorna 2 (Casas incompletas ou maior que a necessária)
            int tam = entrada.Length;
            for (int i = 0; i < tam; i++)
            {
                if (entrada[i] > 47 && entrada[i] < 58)
                {
                    //cout<<entrada[i]<<endl;
                }
                else
                {
                    //cout<<entrada[i];
                    //cout<<" caracter invalido"<<endl;
                    return 1;
                }
            }
            if (tam != 11)
            {
                return 2;
            }
            return 0;
        }

        public int verificacnpj(String entrada)
        {
            //Verifica CPF
            //Se tudo estiver ok, retorna 0
            //Caso contrário retorna 1
            //Se o tamanho da entrada for diferente de 14 retorna 2 (Casas incompletas ou maior que a necessária)
            int tam = entrada.Length;
            for (int i = 0; i < tam; i++)
            {
                if (entrada[i] > 47 && entrada[i] < 58)
                {
                    //cout<<entrada[i]<<endl;
                }
                else
                {
                    //cout<<entrada[i];
                    //cout<<" caracter invalido"<<endl;
                    return 1;
                }
            }
            if (tam != 14)
            {
                return 2;
            }
            return 0;
        }

        public int verificasalario(String entrada)
        {
            //Verifica Salário
            //Se tudo estiver ok, retorna 0
            //Caso contrário retorna 1
            //Caso contrário retorna 2 (Tamanho Mínino 1)
            int tam = entrada.Length;
            if (tam < 1)
            {
                return 2;
            }
            for (int i = 0; i < tam; i++)
            {
                if (entrada[i] > 47 && entrada[i] < 58)
                {
                    //cout<<entrada[i]<<endl;
                }
                else
                {
                    //cout<<entrada[i];
                    //cout<<" caracter invalido"<<endl;
                    return 1;
                }
            }
            return 0;
        }

        public int verificanumeroquarto(String entrada)
        {
            //Verifica Numero do Quarto
            //Se tudo estiver ok, retorna 0
            //Caso contrário retorna 1
            //Se o tamanho da entrada for diferente de 4 retorna 2 (Casas incompletas ou maior que a necessária)
            int tam = entrada.Length;
            for (int i = 0; i < tam; i++)
            {
                if (entrada[i] > 47 && entrada[i] < 58)
                {
                    //cout<<entrada[i]<<endl;
                }
                else
                {
                    //cout<<entrada[i];
                    //cout<<" caracter invalido"<<endl;
                    return 1;
                }
            }
            if (tam != 4)
            {
                return 2;
            }
            return 0;
        }

        public int verificavalor(String entrada)
        {
            //Verifica Valor
            //Se tudo estiver ok, retorna 0
            //Caso contrário retorna 1
            //Caso tenha mais de 2 casas após a vírgula ou se possuir 2 virgulas, retorna 2
            int numeropontos = 0;
            int casas = 0;
            int tam = entrada.Length;
            for (int i = 0; i < tam; i++)
            {
                if (entrada[i] > 47 && entrada[i] < 58)
                {
                    //cout<<entrada[i]<<endl;
                    if (numeropontos > 0)
                    {
                        casas++;
                    }
                    if (casas > 2)
                    {
                        return 2;
                    }
                }
                else
                {
                    if (entrada[i] == 46)
                    {
                        if (numeropontos == 0)
                        {
                            numeropontos++;
                        }
                        else
                        {
                            return 2;
                        }
                    }
                    else
                    {
                        //cout<<entrada[i];
                        //cout<<" caracter invalido"<<endl;
                        return 1;
                    }
                }
            }
            if (numeropontos == 0)
            {
                return 2;
            }
            if (numeropontos == 1 && casas < 2)
            {
                return 2;
            }
            if (entrada.Length > 8)
            {
                return 3;
            }
            return 0;
        }
    }
}
