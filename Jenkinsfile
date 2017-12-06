stage('Checkout SCM') {
    node {
        echo 'Checking out SCM'
        checkout scm
    }
}

stage('Restore packages') {
    node {
		echo 'Restoring packages'
		sh 'dotnet restore'
    }
}

stage('Build Solution') {
	node {
		echo 'Building solution'
		sh 'dotnet build'
	}
}

stage ('Run Unit Tests') {
	node {
		echo 'Running unit tests'
		sh 'dotnet test test/SampleApp.Api.Tests/SampleApp.Api.Tests.csproj'
	}
}

stage ('Publish Application') {
	node {
		echo 'Publishing application'
		sh 'dotnet publish src/SampleApp.Api/SampleApp.Api.csproj -c Release -o deploy'
	}
}