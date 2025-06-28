
1 - Instale o Docker
2 - Pelo CMD vá até a pasta raiz do projeto e digite "docker-compose down -v". Vai iniciar a compilação do projeto e subida dos containers da API, Postgres e NGinx
3 - Acessar swagger pelo link http://localhost:5042/swagger e cadastrar um usuario e senha
4 - Acessar o front pelo link front http://localhost:5173/login
5 - O banco de dados pode ser acessado em: http://localhost:5050,
User: admin@example.com
Pass: secretaryship
6 - Adicione o server: host: 
      POSTGRES_PASSWORD: secretaryship
      POSTGRES_USER: admin
	  POSTGRES_DB: erp_produtos
	  ports:"5432:5432"
	  
	  
	  
	  
Outros comandos:
front http://localhost:5173/login
Acesso ao PgAdmin	http://localhost:5050
Documentação da API	http://localhost:5042/swagger


docker-compose down -v -> limpa bd
docker-compose down -> não limpa
docker-compose up --build -d -> builda