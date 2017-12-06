stage('Checkout SCM') {
    node {
        echo "Checking out ${env.BRANCH_NAME}"
        checkout scm
    }
}

stage('Restore packages') {
    node {
		echo 'Restoring packages'
		sh 'dotnet restore'
    }
}

stage('Build') {
	node {
		echo 'Building solution'
		sh 'dotnet build'
	}
}

stage ('Run Unit Tests') {
	node {
		echo 'Running unit tests'
		sh 'dotnet test'
	}
}