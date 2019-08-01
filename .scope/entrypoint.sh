echo Installing Golang
add-apt-repository ppa:longsleep/golang-backports
apt-get update
apt-get -y upgrade
apt-get install golang-go -y

echo Fix Go Paths
export GOPATH=/go
export PATH=$PATH:$GOPATH/bin

echo Install Stripe Mock
go get -u github.com/stripe/stripe-mock
stripe-mock &

echo Installing the ScopeAgent.Runner
dotnet tool install -g ScopeAgent.Runner

echo Fix Path
export PATH="$PATH:/root/.dotnet/tools"
cd src/StripeTests

echo Clean Solution
dotnet clean

echo Build Solution
dotnet build

echo Run Tests
scope-run dotnet test --framework netcoreapp2.1
