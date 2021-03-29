# DesafioDextra

Para que seja possível executar o acesso aos endpoints, você precisará abrir uma conexão local com o seu mongodb

Abra a solution "DesafioDextra" e vá em appSettings.json para ver se o campo "ConnectionString" é o mesmo que o seu localHost

Após verificar sua conexão com o mongodb, execute os testes no projeto UnitTests para validar sua conexão com o mongodb

Com a execução dos testes, pode executar o projeto DesafioDextra, onde irá se abrir um swagger que terá todos os endpoints necessários

Como será criado uma Base de dados nova com novas coleções, será necessário realizar inserts pelos métodos Post, segue scripts para cada endpoint de inserção:
OBS: Após um personagem ser criado, ele terá um Id, com esse Id, você usará ele para preencher o campo "characterId" dos outros endpoints

​/v1​/public​/Characters​/Create​/Character:
{
  "name": "string"
}

​/v1​/public​/Characters​/Create​/Comic
{
  "title": "string",
  "characterId": "string"
}

/v1/public/Characters/Create/Event
{
  "description": "string",
  "characterId": "string"
}

/v1/public/Characters/Create/Serie
{
  "title": "string",
  "characterId": "string"
}

​/v1​/public​/Characters​/Create​/Story
{
  "resume": "string",
  "characterId": "string"
}

Por fim, logo após que realizar pelo menos um insert em cada collection, utilize dos métodos GET para que consiga realizar sua busca por “characterId”



 