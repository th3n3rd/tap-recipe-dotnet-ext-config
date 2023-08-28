#!/bin/bash

set -e

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" &> /dev/null && pwd)"

WORKLOAD="$SCRIPT_DIR/../config/consumer-workload.yaml"
CONFIG="$SCRIPT_DIR/../config/consumer-config.yaml"
RBAC="$SCRIPT_DIR/../config/configs-access.yaml"

kubectl delete -f "$WORKLOAD" || true
kubectl apply -f "$CONFIG"
kubectl apply -f "$RBAC"
kubectl apply -f "$WORKLOAD"

tanzu apps workload tail consumer
