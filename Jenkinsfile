pipeline {
    agent any

    stages {
        stage('Clone') {
            steps {
                echo 'Cloning source code'
                git branch: 'main', url: 'https://github.com/catsmileyy/Dog.git'
            }
        }

        stage('Restore packages') {
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

        stage('Publish') {
            steps {
                echo 'Publishing project...'
                bat 'dotnet publish -c Release -o ./publish -p:UseAppHost=true -p:PublishProtocol=FileSystem'
            }
        }

                stage('Deploy') {
                    steps {
                        echo 'Deploying to IIS...'
                        powershell '''
                            Import-Module WebAdministration

                            # Create application pool if it doesn't exist
                            if (-not (Test-Path IIS:\\AppPools\\MySite)) {
                                New-WebAppPool -Name "MySite"
                            }

                            # Ensure site exists
                            if (-not (Test-Path IIS:\\Sites\\MySite)) {
                                New-Website -Name "MySite" -Port 81 -PhysicalPath "C:\\ProgramData\\Jenkins\\.jenkins\\workspace\\Dogg\\publish" -ApplicationPool "MySite"
                            } else {
                                Set-ItemProperty IIS:\\Sites\\MySite -Name physicalPath -Value "C:\\ProgramData\\Jenkins\\.jenkins\\workspace\\Dogg\\publish"
                                Set-ItemProperty IIS:\\Sites\\MySite -Name applicationPool -Value "MySite"
                            }

                            # Restart the app pool safely
                            Restart-WebAppPool -Name "MySite"
                        '''
                    }
                }

    }
}
