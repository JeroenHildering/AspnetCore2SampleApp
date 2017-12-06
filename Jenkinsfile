stage('Checkout SCM') {
    node {
        echo 'Checking out SCM'
		retry(3) {
			checkout scm
		}
    }
}

stage('Restore packages') {
    node {
		echo 'Restoring packages'
		retry(3) {
			sh 'dotnet restore'
		}
    }
}

stage('Build Solution') {
	milestone()
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
	milestone()
}

stage ('Publish Application') {
	node {
		echo 'Publishing application'
		sh 'dotnet publish src/SampleApp.Api/SampleApp.Api.csproj -c Release -o deploy'
	}
	milestone()
}

stage ('Deploy to Production') {
	input 'Deploy to production?'
	milestone()
	lock('Deployment to Production') {
		node {
			sh 'dotnet --version'
		}
	}
}