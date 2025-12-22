#!/bin/bash
# copy-datasource.sh
# Copia los archivos CSV del ambiente configurado en appsettings.json a la raíz de DataSource

set -e

SCRIPT_DIR="$(cd "$(dirname "$0")" && pwd)"
PROJECT_ROOT="$SCRIPT_DIR/.."
APPSETTINGS="$PROJECT_ROOT/appsettings.json"

# Verificar que jq esté instalado
if ! command -v jq &> /dev/null; then
    echo "❌ Error: jq no está instalado. Instala con: brew install jq"
    exit 1
fi

# Leer ambiente desde appsettings.json
ENV=$(jq -r .Environment "$APPSETTINGS")

if [ -z "$ENV" ] || [ "$ENV" == "null" ]; then
  echo "❌ No se encontró 'Environment' en appsettings.json"
  exit 1
fi

# Si es local, usar archivos de la raíz directamente
if [ "$ENV" == "local" ]; then
  echo "✅ Ambiente 'local': usando archivos CSV de la raíz de DataSource"
  exit 0
fi

# Determinar carpeta de origen para stage/prod
case "$ENV" in
  stage)
    SOURCE_DIR="$PROJECT_ROOT/DataSource/stage"
    ;;
  prod)
    SOURCE_DIR="$PROJECT_ROOT/DataSource/prod"
    ;;
  *)
    echo "❌ Ambiente no válido: $ENV (debe ser: stage o prod)"
    exit 1
    ;;
esac

# Verificar que existe la carpeta del ambiente
if [ ! -d "$SOURCE_DIR" ]; then
  echo "❌ No existe la carpeta: $SOURCE_DIR"
  exit 1
fi

echo "🔄 Copiando archivos CSV desde ambiente: $ENV"

# Limpiar archivos CSV existentes en la raíz de DataSource
rm -f "$PROJECT_ROOT/DataSource"/*.csv

# Copiar archivos CSV del ambiente a la raíz
if ! cp "$SOURCE_DIR"/*.csv "$PROJECT_ROOT/DataSource/" 2>/dev/null; then
  echo "⚠️  No se encontraron archivos CSV en $SOURCE_DIR"
  exit 1
fi

echo "✅ Archivos CSV copiados exitosamente desde: $ENV"
