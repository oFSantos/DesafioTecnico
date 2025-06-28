# Etapa de build
FROM node:18 AS build
WORKDIR /app
COPY . .
RUN npm install
RUN npm run build

# Etapa de produção - serve com nginx
FROM nginx:stable-alpine
COPY --from=build /app/dist /usr/share/nginx/html

# Remove configuração default
RUN rm /etc/nginx/conf.d/default.conf

# Adiciona nossa configuração
COPY nginx.conf /etc/nginx/conf.d

EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
