# Marvel API
Reimplementação de alguns endpoints da Marvel API para mostrar ao Thanos que juntos somos invencíveis.

## How To
Para testar os endpoints, basta clonar o respositório em sua máquina e buildar. Todos os scripts necessários para inicialização (criação de banco de dados, tabelas, dados, etc.) serão executados no startup da aplicação. Você poderá usar o próprio swagger da aplicação para testar os endpoints implementados. 

### Endpoints implementados

* `/v1/characters`
* `/v1/characters/{characterId}`
* `/v1/characters/{characterId}/comics`
* `/v1/characters/{characterId}/events`
* `/v1/characters/{characterId}/series`
* `/v1/characters/{characterId}/stories`

### Observações
Com exceção do endpoint `/v1/characters/{characterId}` é obrigatório informar o parâmetro Limit nas requisições. Além disso, todos os dados da API são fictícios.

### Importante
Aplicação desenvolvida em .NET Core V2.2.106.
