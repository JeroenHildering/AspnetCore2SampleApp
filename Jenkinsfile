properties([[$class: 'jenkins.model.BuildDiscarderProperty', strategy: [$class: 'LogRotator', numToKeepStr: '5']]])

stage('Checkout SCM') {
    node {
		echo 'Clean workspace'
		deleteDir()
        echo 'Checking out SCM'
		retry(3) {
			checkout scm
		}
    }
}

stage('Build') {
	milestone()
	node {
		echo 'Restoring packages'
		retry(3) {
			sh 'dotnet restore'
		}
		echo 'Building solution'
		sh 'dotnet build'
	}
}

stage ('Test') {
	node {
		echo 'Running unit tests'
		sh 'dotnet test test/SampleApp.Api.Tests/SampleApp.Api.Tests.csproj'
	}
	milestone()
}

stage ('Publish') {
	node {
		echo 'Publishing application'
		sh 'dotnet publish src/SampleApp.Api/SampleApp.Api.csproj -c Release -o ../../deploy'
		archiveArtifacts artifacts: 'deploy/**/*.*', fingerprint: true
	}
	milestone()
}