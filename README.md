# Controle de Cinema

   Com a necessidade de gerenciar melhor as vendas de ingressos do Cinema de Lages, foi proposto pelo dono do Cinema o Sr. João do Nascimento, a criação de um sistema que auxilia no controle das vendas dos ingressos para os clientes que desejam assistir os filmes e comer aquela pipoca nos finais de semana. 
   
   A equipe do Cinema deseja otimizar o controle de um conjunto de salas e agilizar o processo de venda dos ingressos aos clientes. Atualmente, a equipe utiliza formulários de papel para armazenar as informações dos ingressos que já foram vendidos e ainda os ingressos que estão disponíveis, como também as capacidades das salas. 
   
---

## Requisitos Funcionais:

- O sistema deve registrar informações sobre cada sala, como sua capacidade total e o número de assentos disponíveis.
- O sistema deve registrar informações importantes sobre cada filme, como título, duração e gênero.
- O sistema deve permitir que os funcionários registrem novos lançamentos no acervo do cinema.
- O sistema deve registrar sessões, associando cada sessão a um filme, uma sala e um horário específico.
- O sistema deve determinar o número máximo de ingressos disponíveis para uma sessão com base na capacidade da sala onde a sessão acontece.
- O sistema deve permitir que um funcionário intermedie a venda de ingressos.
- O sistema deve incluir informações sobre o tipo de ingresso (inteiro ou meio ingresso) em cada ingresso.
- O sistema deve garantir que os clientes só possam comprar ingressos para sessões que ainda não foram encerradas.
- O sistema deve respeitar a capacidade máxima de cada sala durante a venda de ingressos.
- O sistema deve permitir que os funcionários visualizem as sessões do dia agrupadas por filme, incluindo tanto as sessões em andamento quanto aquelas ainda por serem iniciadas.
- O sistema deve possuir um módulo de cadastro que permita a consulta, inclusão, alteração e remoção de sessões.
- O sistema deve apresentar os detalhes das sessões, mostrando as poltronas disponíveis e já vendidas.

## Requisitos Não Funcionais:

**Ambiente**
-  A aplicação poderá ser acessada a partir de um navegador de internet (browser).

**Persitência das Informações**
- Os dados devem ser salvos e recuperados em banco de dados utilizando ORM.

**Arquitetural**
- Deve-se trabalhar utilizando o modelo de camadas.

**Qualidade**
- Deve-se criar testes automatizados para os componentes da aplicação
- Deve-se criar a documentação do projeto, prototipos, diagramas e README

---

## Requisitos

- .NET SDK (recomendado .NET 8.0 ou superior) para compilação e execução do projeto.

---

## Como Usar

#### Clone o Repositório
```
git clone https://github.com/Nick-E-Judy/controle-de-cinema-2024.git
```

#### Navegue até a pasta raiz da solução
```
cd controle-de-cinema-2024
```

#### Restaure as dependências
```
dotnet restore
```

#### Navegue até a pasta do projeto
```
cd ControleDeCinema.WinApp
```

#### Execute o projeto
```
dotnet run
```


