#!/bin/bash
echo "Esperando o PostgreSQL ficar disponível..."

until pg_isready -h db -p 5432 -U postgres; do
  sleep 2
done

echo "PostgreSQL está disponível. Iniciando a aplicação..."
exec "$@"
