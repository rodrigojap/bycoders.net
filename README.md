# Requisitos da aplicação
Para poder executar o projeto é necessário ter o docker instalado. A versão utilizada para os testes desta aplicação foi: 24.0.5 (Você pode ver sua versão executando 'docker --version')

# Importante
Para não precisar alterar nada no projeto, basta manter as portas 3000, do front-end, 5001 da api e 5432 do banco de dados disponíveis. Caso contrátio será necessário alterá-las no dockerfile e no docker-compose.yml

# Como executar ?
Na pasta raiz do projeto existe o arquivo **docker-compose.yml**, certifique-se que está no mesmo diretório e execute o comando 'docker compose up -d'. O download e instalação das imagens gira em torno de 2 a 3 minutos (pode variar dependendo da internet). Após a intalação você deve receber um output como esse:![expected_docker_install](https://github.com/rodrigojap/bycoders.net/assets/5871573/ae4d17f1-1e8e-4332-9c1e-d3d9d1e31634)
Caso algum erro ocorra, delete os container e faça o compose mais uma vez.(Já tive alguns problemas com download e as imagens ficaram corrompidas) 

# Verificando os Containers
A aplicação é composta por 3 containers: **bycoders.database**, **bycoders.cnab.api** e **bycoders.cnab.web**. Na tela inicial do docker é possível visualizá-los:
![expected_containers](https://github.com/rodrigojap/bycoders.net/assets/5871573/0b7f4672-39b2-4ac7-95ae-f6bb3f2b0614)

Os containers **bycoders.cnab.api** e **bycoders.cnab.web** depois de criados, costumar levar alguns segundos para serem totalmente inicializados. Pra ter certeza que tudo está certo podemos ver o seguinte:

**bycoders.cnab.api** -> Visualizar os logs de inicialização do asp.net. Se esses logs já estiverem visíveis, a aplicação já está pronta. Para garantir a vitória basta acessar o swagger e visualizar os métodos. http://localhost:5001/swagger/index.html
![image](https://github.com/rodrigojap/bycoders.net/assets/5871573/56a95ced-4453-49d7-8bdb-11cf83409458) ![image](https://github.com/rodrigojap/bycoders.net/assets/5871573/5afacb67-a694-4728-a071-ef4ad0eea1d7)


**bycoders.cnab.web** -> Visualizar os logs de inicialização do next.js. Se esses logs já estiverem visíveis, a aplicação já está pronta:
![image](https://github.com/rodrigojap/bycoders.net/assets/5871573/de313b13-a17d-48df-950e-db9153893a18)

Depois disso, basta acessar http://localhost:3000/ e visualizar a tela inicial da aplicação:
![image](https://github.com/rodrigojap/bycoders.net/assets/5871573/00335f63-4238-4128-b959-5f8ed4653115)
