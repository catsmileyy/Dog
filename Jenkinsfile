pipeline {
    agent any

    stages {
        stage('Clone') {
            steps {
                echo 'Cloning source code...'
                git branch: 'main', url: 'https://github.com/catsmileyy/Dog.git'
            }
        }

        stage('Restore Packages') {
            steps {
                echo 'Restoring packages...'
                bat 'dotnet restore'
            }
        }

        stage('Build') {
            steps {
                echo 'Building project...'
                bat 'dotnet build --configuration Release'
            }
        }

        stage('Test') {
            steps {
                echo 'Running tests...'
                bat 'dotnet test --no-build --verbosity normal'
            }
        }

        stage('Publish to Folder') {
            steps {
                echo 'Publishing to ./publish folder...'
                bat 'dotnet publish -c Release -o ./publish'
            }
        }

        stage('Copy to IIS Folder') {
            steps {
                echo 'Copying to IIS folder...'
                bat 'xcopy "%WORKSPACE%\\publish" /E /Y /I /R "C:\\wwwroot\\DogProject"'
            }
        }

        stage('Deploy to IIS') {
            steps {
                powershell '''
                Import-Module WebAdministration
                if (-not (Test-Path IIS:\\Sites\\DogSite)) {
                    New-Website -Name "DogSite" -Port 81 -PhysicalPath "C:\\wwwroot\\DogProject"
                }
                '''
            }
        }
    }
}