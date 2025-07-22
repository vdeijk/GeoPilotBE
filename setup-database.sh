#!/bin/bash

# Setup script for new developers
echo "Setting up development database..."

# Navigate to BE.Web and apply migrations
cd BE.Web
echo "Applying database migrations..."
dotnet ef database update

# Navigate to DataImporter and run data import
cd ../BE.Data/DataImporter
echo "Importing seed data..."
dotnet run

echo "Database setup complete!"
echo "You can now run the web application with: dotnet run --project BE.Web"
