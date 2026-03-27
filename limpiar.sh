#!/bin/bash

echo "🧹 Limpiando proyecto RutaRD..."

# Eliminar carpetas bin y obj
find . -type d -name "bin" -exec rm -rf {} + 2>/dev/null
find . -type d -name "obj" -exec rm -rf {} + 2>/dev/null

# Eliminar carpetas .vs y .idea
find . -type d -name ".vs" -exec rm -rf {} + 2>/dev/null
find . -type d -name ".idea" -exec rm -rf {} + 2>/dev/null

echo "✅ Limpieza completada"
echo ""
echo "📂 Estructura del proyecto:"
tree -L 2 -I 'bin|obj|.vs|.idea|lib' || ls -R

echo ""
echo "🔄 Para reconstruir el proyecto:"
echo "   dotnet clean"
echo "   dotnet restore"
echo "   dotnet build"
