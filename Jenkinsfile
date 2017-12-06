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
		dir ('test/SampleAppi.Api.Tests') {
			sh 'dotnet xunit --fx-version 2.0.0 -xml ../../test-results.xml'
		}
		junit 'test-results.xml'
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